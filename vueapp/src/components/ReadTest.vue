<template>
<v-card rounded="xl" class="px-8 pt-8" color="white">
    <VCardTitle class="text-start text-h4 mb-3">
        Book Title
    </VCardTitle>
    <v-card-text>
        <p class="text-body-1 text-left">{{ currentPage.content }}</p>
    </v-card-text>

    <div>
      <v-btn rounded="lg" style="float: left; position: relative;" color="primary" @click="previousPage">Previous</v-btn>
      <v-btn rounded="lg" style="float: left; position: relative;" color="primary" @click="nextPage">Next</v-btn>
    </div>
</v-card>
</template>   
        
<script lang="js">
import { defineComponent } from 'vue';
export default {
  data() {
    return {
      currentPageIndex: 0,
      pages: [
        { id: 1, content: "Page 1, Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur sed lorem ut arcu commodo tincidunt. Phasellus porttitor tincidunt nisl, a auctor quam auctor eu. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam consequat iaculis ultricies. Aliquam condimentum posuere odio, feugiat aliquam eros eleifend sed. Sed semper, urna vitae interdum aliquet, felis mi ultrices quam, non porta enim ante sed lacus. Nunc hendrerit nibh sapien, non pretium nunc lacinia nec. Morbi consequat dolor quis dictum imperdiet. Etiam viverra, ante et viverra efficitur, arcu mi congue augue, vel feugiat lacus nisi non ante. Vivamus vitae scelerisque purus, ac egestas turpis. Ut lacus eros, sagittis a maximus ut, fermentum non orci. Nulla risus mi, accumsan eget erat sodales, pretium dignissim sem. Integer egestas justo molestie urna faucibus iaculis. Phasellus at odio et lacus viverra fermentum vel eget arcu. Mauris auctor consectetur tortor. Donec non mauris at orci ullamcorper facilisis fermentum nec orci." },
        { id: 2, content: "Page 2, Phasellus libero magna, elementum in metus vel, elementum commodo nibh. Cras a aliquet risus. Morbi convallis, urna eu pulvinar ultricies, magna turpis convallis nisi, nec pellentesque elit quam id risus. Integer et interdum nisi. Vestibulum rhoncus luctus tristique. Sed aliquam luctus elit, eget tempor velit accumsan eu. Nulla egestas dignissim ultrices. Donec in ante varius nulla lacinia congue. Donec tristique auctor consectetur. Etiam vestibulum lorem non tellus commodo, ut eleifend ligula lobortis. Aliquam urna ex, malesuada at sollicitudin in, finibus sodales leo. Nullam leo quam, ornare vel magna sed, vulputate aliquam mauris. Proin sagittis tristique ante at commodo." },
        { id: 3, content: "Page 3, Proin lacus arcu, condimentum nec justo ut, mollis fringilla ipsum. Proin cursus leo id ante feugiat rutrum. Phasellus ac pretium nisi, tincidunt scelerisque dolor. Etiam nec aliquet nunc. Integer dictum nibh ut erat gravida ultricies. Vivamus lacus felis, fringilla ut pretium non, convallis ac mauris. Duis egestas elit suscipit, convallis nulla sed, scelerisque purus. Fusce sed turpis ipsum. Vestibulum ac lorem sit amet nisi egestas auctor eget sed mauris. Phasellus ut condimentum metus, in commodo augue. Nulla ultrices blandit velit, sit amet suscipit ligula scelerisque eget. Nulla elementum tortor quis massa cursus posuere. Aenean commodo quis orci et rhoncus." },
        // Add more pages as needed
      ],
    };
  },
  computed: {
    currentPage() {
      return this.pages[this.currentPageIndex];
    },
  },
  methods: {
    previousPage() {
      if (this.currentPageIndex > 0) {
        this.currentPageIndex--;
      }
    },
    nextPage() {
      if (this.currentPageIndex < this.pages.length - 1) {
        this.currentPageIndex++;
      }
    },
  },
};
</script>
        